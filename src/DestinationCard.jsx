export default function DestinationCard({ title, imgSrc, link }) {
  return (
    <div className="destinatie">
      <a href={link}><img src={imgSrc} alt={title} /></a>
      <div className="text">
        <span className="titlu">{title}</span>
      </div>
    </div>
  );
}
