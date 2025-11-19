
import { Link } from "react-router-dom";

export default function DestinationCard({ id, title, bannerImg }) {
  return (
    <Link to={`/destinatie/${id}`} className="destinatie">
      <img src={bannerImg} alt={title} />
      <div className="text">
        <span className="titlu">{title}</span>
      </div>
    </Link>
  );
}
