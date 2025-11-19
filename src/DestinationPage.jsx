
import { useParams } from "react-router-dom";
import { useState } from "react";

const DateRangePicker = ({ onChange, value }) => (
  <input 
    type="text" 
    placeholder="📅 Alege Perioada (ex: 12-17 iunie)" 
    value={value}
    onChange={onChange}
    required 
  />
);

export default function DestinationPage({ destinations }) {
  const { link } = useParams();
  const dest = destinations.find(d => d.id === link);

  const [reviews, setReviews] = useState([
    { name: "Alex", stars: 5, comment: "A fost o experiență minunată! Recomand cu drag!" },
    { name: "Andrei", stars: 4, comment: "Peisaje superbe, cazarea putea fi mai bună." }
  ]);

  const [newReview, setNewReview] = useState({ name: "", stars: 0, comment: "" });

  const [bookingData, setBookingData] = useState({ name: "", email: "", period: "" });

  if (!dest) return <h1 className="error-message">Destinația nu există!</h1>;

  
  const handleReviewSubmit = (e) => {
    e.preventDefault();
    if(newReview.name && newReview.comment && newReview.stars >= 1 && newReview.stars <= 5){
      setReviews([newReview, ...reviews]); 
      setNewReview({ name: "", stars: 0, comment: "" });
    }
  };
  
  const handleBookingSubmit = (e) => {
    e.preventDefault();
    console.log("Rezervare trimisă:", bookingData);
    alert(`Rezervarea pentru ${bookingData.name} în perioada ${bookingData.period} a fost trimisă!`);
    setBookingData({ name: "", email: "", period: "" });
  };

  
  return (
    <div className="destination-page">

      <div className="dest-header-banner" style={{ backgroundImage: `url(${dest.bannerImg})` }}>
        <div className="dest-banner-overlay">
          <div className="header-content">
            <h1>{dest.title}</h1>
            <div className="info-cards-header">
              <div className="info-card-header">
                <strong>Preț:</strong> <span>1200 USD</span>
              </div>
              <div className="info-card-header">
                <strong>Rating:</strong> <span>4.5/5 ⭐</span>
              </div>
              <div className="info-card-header">
                <strong>Durată:</strong> <span>5 zile</span>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="content-padding-wrapper">
        
        {/* 2. Detalii */}
        <div className="dest-details-section">
            <h2>🌍 Despre Destinație</h2>
            <p className="dest-description">{dest.descriere}</p>
        </div>

        <div className="dest-gallery-original">
            <h2>📸 Galerie Foto</h2>
            <div className="gallery-grid-original-flex">
                {dest.galerie.map((img, i) => (
                    <img key={i} src={img} alt={`${dest.title}-${i}`} />
                ))}
            </div>
        </div>
        
        <div className="booking-section-full-width">
            <div className="booking-form-card-wide">
                <h2>✈️ Rezervă Călătoria</h2>
                <div className="booking-content-grid">
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
                        <DateRangePicker 
                            value={bookingData.period}
                            onChange={e => setBookingData({ ...bookingData, period: e.target.value })}
                        />
                         <div className="price-calculation-placeholder">
                            <h3>Total Estimat:</h3>
                            <p className="final-price">1200 USD</p>
                            <p className="price-note">(Prețul include transportul și cazarea pentru 5 zile. Calculele detaliate vor fi disponibile curând.)</p>
                         </div>
                        <button type="submit">Finalizează Rezervarea</button>
                    </form>
                    
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