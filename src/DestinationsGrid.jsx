import DestinationCard from "./DestinationCard";

export default function DestinationsGrid({ destinations }) {
  return (
    <div className="continut">
      {destinations.map((dest, index) => (
        <DestinationCard
          key={index}
          title={dest.title}
          imgSrc={dest.imgSrc}
          link={dest.link}
        />
      ))}
    </div>
  );
}
