
import DestinationCard from "./DestinationCard";

export default function DestinationsGrid({ destinations }) {
  return (
    <div className="continut">
      {destinations.map((d) => (
        <DestinationCard 
          key={d.id} 
          id={d.id} 
          title={d.title} 
          bannerImg={d.bannerImg} 
        />
      ))}
    </div>
  );
}
