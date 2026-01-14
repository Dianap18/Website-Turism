import DestinationCard from "./DestinationCard";

export default function DestinationsGrid({ destinations }) {
  
  if (!destinations) return <p>Se încarcă...</p>;

  return (
    <div className="destinations-grid-container">
      <div className="continut">
        {destinations.length === 0 ? (
            <h3 style={{textAlign: 'center', width: '100%', padding: '20px'}}>
                Nu am găsit destinații pentru filtrele selectate.
            </h3>
        ) : (
            destinations.map((dest) => {
            let averageRating = 0;
            if (dest.reviews && dest.reviews.length > 0) {
                const totalStars = dest.reviews.reduce((acc, review) => acc + review.stars, 0);
                averageRating = (totalStars / dest.reviews.length).toFixed(1); 
            } else {
                averageRating = "-"; 
            }

            return (
                <DestinationCard 
                key={dest.id} 
                slug={dest.slug} 
                title={dest.title} 
                bannerImg={dest.bannerImg}
                price={dest.price}
                stars={averageRating}
                />
            );
            })
        )}
      </div>
    </div>
  );
}