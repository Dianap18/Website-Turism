import { useState } from 'react';
import './FiltersSection.css';


export default function FiltersSection({ onFilterApply }) {
  
  const [rating, setRating] = useState("Toate");
  const [minPrice, setMinPrice] = useState(""); 
  const [maxPrice, setMaxPrice] = useState(""); 
  const [activity, setActivity] = useState("Toate");

  // imacheteaza troate var intr-un obiect apoi apeleaza functia parinte
  const handleFilterClick = () => {
    onFilterApply({
      rating,
      minPrice, 
      maxPrice, 
      activity
    });
  };

  return (
    <section className="filters-section">
      <h2 className="section-title"> Toate Destinațiile </h2>

      <div className="filters-row">
        
        <div className="filter-item stylish-select">
          <label htmlFor="rating-select"> Rating:</label>
          <select 
            id="rating-select" 
            value={rating}
            onChange={(e) => setRating(e.target.value)} 
          >
            <option value="Toate">Toate</option>
            <option value="5">5 stele</option>
            <option value="4">4+ stele</option>
            <option value="3">3+ stele</option>
          </select>
        </div>

        <div className="filter-item">
          <label htmlFor="min-price"> Preț Min (€):</label>
          <input 
            type="number" 
            id="min-price"
            placeholder="0"
            value={minPrice}
            onChange={(e) => setMinPrice(e.target.value)}
          />
        </div>

        <div className="filter-item">
          <label htmlFor="max-price"> Preț Max (€):</label>
          <input 
            type="number" 
            id="max-price"
            placeholder="Max"
            value={maxPrice}
            onChange={(e) => setMaxPrice(e.target.value)}
          />
        </div>

        <div className="filter-item stylish-select">
          <label htmlFor="activity-select"> Activitate:</label>
          <select 
            id="activity-select"
            value={activity}
            onChange={(e) => setActivity(e.target.value)}
          >
            <option value="Toate">Toate</option>
            <option value="Mare">Mare</option>
            <option value="Munte">Munte</option>
            <option value="City Break">City Break</option>
          </select>
        </div>
        
        <button className="filter-button" onClick={handleFilterClick}>
          Filtrează
        </button>
      </div>
    </section>
  );
}