import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import DatePicker from "react-datepicker"; 
import "react-datepicker/dist/react-datepicker.css"; 

import { registerLocale } from "react-datepicker";
import ro from 'date-fns/locale/ro';
registerLocale('ro', ro); //Configuram calendarul să fie în limba română

export default function DestinationPage() {
  const { link } = useParams();
  
  const [dest, setDest] = useState(null);
  const [loading, setLoading] = useState(true);
  const [displayedText, setDisplayedText] = useState(""); 
  const [reviews, setReviews] = useState([]); 
  const [newReview, setNewReview] = useState({ name: "", stars: 0, comment: "" });
  const [dateRange, setDateRange] = useState([null, null]);
  const [startDate, endDate] = dateRange; 
  const [bookingData, setBookingData] = useState({ name: "", email: "" });

  useEffect(() => {
    // ia datele din baza de date 
    fetch(`http://localhost:5286/api/destinations/${link}`)
      .then(res => {
        if (!res.ok) throw new Error("Destinatia nu exista");
        return res.json();
      })
      // Luăm datele și le punem în variabila de stare dest, review urile in lista lor separata
      .then(data => {
        setDest(data);
        if (data.reviews) setReviews(data.reviews);
        setLoading(false);
      })
      .catch(err => {
        console.error(err);
        setLoading(false);
      });
  }, [link]);

  // partea de scriere a descrierii, la fiecare 25 de secunde scrie un caracter 
  useEffect(() => {
    if (dest && dest.description) {
      let index = 0;
      setDisplayedText(""); 
      const fullText = dest.description;

      const intervalId = setInterval(() => {
        setDisplayedText((prev) => prev + fullText.charAt(index));
        index++;
        if (index === fullText.length) {
          clearInterval(intervalId);
        }
      }, 25); 

      return () => clearInterval(intervalId); 
    }
  }, [dest]); 

  const calculateAverageRating = () => {
      if (!reviews || reviews.length === 0) return "Nou";
      const totalStars = reviews.reduce((acc, review) => acc + review.stars, 0);
      return (totalStars / reviews.length).toFixed(1); 
  };

  const averageRating = calculateAverageRating();

  const calculateTotal = () => {
    if (!startDate || !endDate || !dest) return 0;
    const diffTime = Math.abs(endDate - startDate);
    const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)); //Aici transformăm milisecundele în zile
    const nights = diffDays === 0 ? 1 : diffDays;

    return {
        nights: nights, // cate nopti afisam
        total: nights * dest.price // pretul total 
    };
  };

  const bookingInfo = calculateTotal(); // se apelează funcția de fiecare dată când pagina se randează

  // trimite recenzia scirsa de utilizator
  const handleReviewSubmit = async (e) => {
    e.preventDefault();
    if(newReview.name && newReview.comment && newReview.stars >= 1 && newReview.stars <= 5){
      try {
        const response = await fetch(`http://localhost:5286/api/destinations/${link}/reviews`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' }, // trimitem text JSON
            body: JSON.stringify({
                name: newReview.name,
                stars: newReview.stars,
                comment: newReview.comment
            })
        });

        if (response.ok) {
            setReviews([...reviews, newReview]); // luam lista veche si lipim la sfarsit noua recenzie
            setNewReview({ name: "", stars: 0, comment: "" });
            alert("Recenzia a fost salvată!");
        } else {
            alert("Eroare la salvarea recenziei.");
        }
      } catch (error) {
        console.error("Eroare review:", error);
        alert("Serverul nu răspunde.");
      }
    } else {
        alert("Te rugăm să completezi toate câmpurile corect.");
    }
  };
  
  const handleBookingSubmit = async (e) => {
    e.preventDefault();
    if (!startDate || !endDate) {
        alert("Te rugăm să selectezi o perioadă validă.");
        return;
    }
    const formattedPeriod = `${startDate.toLocaleDateString('ro-RO')} - ${endDate.toLocaleDateString('ro-RO')}`;
    
    const reservationPayload = {
        name: bookingData.name,
        email: bookingData.email,
        period: formattedPeriod,
        totalPrice: bookingInfo.total,
        destinationId: dest.id
    };

    try {
        const response = await fetch(`http://localhost:5286/api/bookings`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(reservationPayload)
        });

        if (response.ok) {
            alert(`Rezervarea pentru ${bookingData.name} a fost trimisă!\nTotal de plată: ${bookingInfo.total} USD`);
            setBookingData({ name: "", email: "" });
            setDateRange([null, null]); 
        } else {
            alert("Eroare la server. Verifică datele.");
        }
    } catch (error) {
        console.error("Eroare rețea:", error);
        alert("Nu am putut contacta serverul.");
    }
  };

  if (loading) return <h2>Se încarcă datele din server...</h2>;
  if (!dest) return <h1 className="error-message">Destinația nu există!</h1>;

  return (
    <div className="destination-page">

      <div className="dest-header-banner" style={{ backgroundImage: `url(${dest.bannerImg})` }}>
        <div className="dest-banner-overlay">
          <div className="header-content">
            <h1>{dest.title}</h1>
            <div className="info-cards-header">
              <div className="info-card-header">
                <strong>Preț / Noapte:</strong> <span>{dest.price} €</span>
              </div>
              <div className="info-card-header">
                <strong>Rating:</strong> <span>{averageRating === "Nou" ? "Nou" : `${averageRating}/5`} ⭐</span>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="content-padding-wrapper">
        
        <div className="dest-details-section">
            <h2>🌍 Despre Destinație</h2>
            <p className="dest-description">
                {displayedText}
                <span className="cursor-blink"></span>
            </p>
        </div>

        <div className="dest-gallery-original">
            <h2>📸 Galerie Foto</h2>
            <div className="gallery-grid-original-flex">
                {dest.gallery && dest.gallery.map((imgObj, i) => (
                    <img key={i} src={imgObj.url} alt={`${dest.title}-${i}`} />
                ))}
            </div>
        </div>
        
        <div className="booking-section-full-width">
            <h2 className="section-headline">Planifică-ți Călătoria</h2>
            
            <div className="booking-split-container">
                
                <div className="booking-form-wrapper">
                    <h3>Rezervă Acum</h3>
                    <form onSubmit={handleBookingSubmit} className="booking-form-inputs">
                        <input 
                            type="text" 
                            placeholder="Numele tău complet" 
                            value={bookingData.name}
                            onChange={e => setBookingData({ ...bookingData, name: e.target.value })}
                            required 
                        />
                        <input 
                            type="email" 
                            placeholder="Adresa de Email" 
                            value={bookingData.email}
                            onChange={e => setBookingData({ ...bookingData, email: e.target.value })}
                            required 
                        />
                        
                        <div className="custom-datepicker-wrapper">
                            <DatePicker
                                selectsRange={true}
                                startDate={startDate}
                                endDate={endDate}
                                onChange={(update) => setDateRange(update)}
                                isClearable={true}
                                placeholderText="📅 Alege Perioada"
                                dateFormat="dd/MM/yyyy"
                                minDate={new Date()} 
                                className="calendar-input" 
                                locale="ro"
                                required
                            />
                        </div>

                         <div className="price-calculation-placeholder">
                            <h3>Total Estimat:</h3>
                            {bookingInfo !== 0 ? (
                                <>
                                    <p className="final-price">{bookingInfo.total} €</p>
                                    <p className="price-note">
                                        Calculat pentru <strong>{bookingInfo.nights}</strong> nopți
                                    </p>
                                </>
                            ) : (
                                <p className="price-note">Alege datele pentru preț.</p>
                            )}
                         </div>

                        <button type="submit">Trimite Cererea</button>
                    </form>
                </div>

                <div className="accommodation-preview-card">
                    <div className="acc-image-wrapper">
                        <img 
                            src="/hotel.png"
                            alt="Cazare Hotel" 
                        />
                        <div className="acc-overlay-hint">
                            <span>🔍 Da click pentru a vedea cazarea</span>
                        </div>
                    </div>
                    
                    <div className="acc-content">
                        <div>
                            <h3>Aceasta va fi cazarea ta 🏨</h3>
                            <p>
                                Am selectat pentru tine un hotel premium.
                                Bucură-te de confort, priveliște și servicii de top.
                            </p>
                            
                            <div className="special-offer-text">
                                <strong>💡 Ofertă Exclusivă!</strong>
                                Dacă rezervi direct prin platforma noastră, te bucuri de multe alte beneficii.
                            </div>
                        </div>

                        <a 
                            href={dest.hotelUrl || "#"} 
                            target="_blank" 
                            rel="noopener noreferrer"
                            className="booking-btn-external" 
                            style={{
                                background: '#3b82f6', 
                                color: 'white', 
                                border: 'none', 
                                width: '100%', 
                                padding: '15px', 
                                borderRadius: '10px', 
                                fontWeight: 'bold', 
                                cursor: 'pointer', 
                                display: 'block', 
                                textAlign: 'center', 
                                textDecoration: 'none', 
                                marginTop: 'auto',
                                boxSizing: 'border-box'
                            }}
                        >
                            Vezi Detalii Hotel
                        </a>
                    </div>
                </div>

            </div>

            <div className="promo-benefits-blue">
                <h4>🎁 Beneficii incluse la rezervare</h4>
                <div className="benefits-list">
                    <div className="benefit-item">🎟️ Discount Intrări Muzee</div>
                    <div className="benefit-item">🚶‍♂️ Tur Ghidat Gratuit</div>
                    <div className="benefit-item">🛡️ Asistență 24/7</div>
                    <div className="benefit-item">🚕 Transfer Aeroport</div>
                </div>
            </div>

        </div>
      </div> 

      <div className="reviews-section-asym">
        <h2>✨ Review-uri ({reviews.length})</h2>
        <div className="reviews-content-container-asym">
          <div className="reviews-list-asym">
            {reviews.map((r, i) => (
              <div key={i} className="review-card-asym">
                <p className="review-header">
                  <strong>{r.name}</strong> 
                  <span className="review-stars">{"⭐".repeat(r.stars)}</span>
                </p>
                <p className="review-comment">{r.comment}</p>
              </div>
            ))}
          </div>

          <div className="new-review-form-asym">
            <h3>Spune-ne părerea ta</h3>
            <form onSubmit={handleReviewSubmit}>
              <input 
                type="text" 
                placeholder="Numele tău" 
                value={newReview.name} 
                onChange={e => setNewReview({ ...newReview, name: e.target.value })} 
                required 
              />
              <input 
                type="number" 
                placeholder="Stelute (1-5)" 
                min="1" 
                max="5" 
                value={newReview.stars} 
                onChange={e => setNewReview({ ...newReview, stars: parseInt(e.target.value) })} 
                required 
              />
              <textarea 
                placeholder="Comentariu detaliat" 
                value={newReview.comment} 
                onChange={e => setNewReview({ ...newReview, comment: e.target.value })} 
                required
              />
              <button type="submit">Trimite Review</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}