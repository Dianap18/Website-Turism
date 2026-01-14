import { Link } from "react-router-dom";
import './TopDestinations.css';

export default function TopDestinations({ destinations }) {
  
  const getAverageRating = (reviews) => {
    if (!reviews || reviews.length === 0) return 0;
    const total = reviews.reduce((acc, r) => acc + r.stars, 0);
    return total / reviews.length;
  };

  // sortare descrescatoare, luam doar primele 3 cu slice
  const top3 = [...destinations]
    .sort((a, b) => getAverageRating(b.reviews) - getAverageRating(a.reviews))
    .slice(0, 3);

  if (top3.length === 0) return null;

  return (
    <section className="top-section-wrapper">
        <div className="top-header-container">
            <h2 className="top-main-title">Cele mai apreciate destinații</h2>
            <p className="top-subtitle">Descoperă locurile favorite ale călătorilor noștri</p>
        </div>
        
        <div className="top-cards-grid">
            {top3.map((dest, index) => {
                const avg = getAverageRating(dest.reviews).toFixed(1);
                
                // Configurare badge pentru locurile 1, 2, 3
                let rankLabel = `#${index + 1}`; // Generează #1, #2, #3
                let rankColorClass = `rank-bg-${index + 1}`; // Generează clase CSS dinamice: rank-bg-1, rank-bg-2...
                let icon = "";
                
                if(index === 0) icon = "👑";
                if(index === 1) icon = "🔥";
                if(index === 2) icon = "✨";

                return (
                    <Link to={`/destinatie/${dest.slug}`} key={dest.id} className="top-card-item">
                        
                        {/* Imaginea cu efect de zoom */}
                        <div className="top-image-box">
                            <img src={dest.bannerImg} alt={dest.title} />
                            
                            {/* Eticheta plutitoare */}
                            <div className={`top-rank-badge ${rankColorClass}`}>
                                <span className="rank-icon">{icon}</span> 
                                <span className="rank-number">{rankLabel}</span>
                            </div>
                        </div>

                        {/* Conținutul text */}
                        <div className="top-content-box">
                            <div className="top-row-header">
                                <h3 className="top-card-title">{dest.title}</h3>
                                <div className="top-rating-pill">
                                    ★ {avg === "0.0" ? "-" : avg}
                                </div>
                            </div>
                            
                            <div className="top-row-footer">
                                <span className="top-price-label">Preț per persoană</span>
                                <span className="top-price-value">{dest.price} €</span>
                            </div>
                        </div>
                    </Link>
                );
            })}
        </div>
    </section>
  );
}