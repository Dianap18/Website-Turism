import { Link } from "react-router-dom";

export default function DestinationCard({ slug, title, bannerImg, price, stars }) {
  return (
    <Link to={`/destinatie/${slug}`} className="destinatie">
      
      <img src={bannerImg} alt={title} />

      <div className="card-badge">
        <span className="card-price">{price} €</span>
        <div className="card-rating">
          <span>{stars}</span>
          <span className="star-icon">★</span>
        </div>
      </div>

      <div className="text">
        <span className="titlu">{title}</span>
      </div>
    </Link>
  );
}