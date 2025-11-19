export default function FiltersSection() {
  return (
    <section className="filters-section">
      <h2 className="section-title"> Toate Destinațiile </h2>

      <div className="filters-row">
        {/* Elementele de filtrare */}
        <div className="filter-item stylish-select">
          <label htmlFor="rating-select"> Rating:</label>
          <select id="rating-select">
            <option>Toate</option>
            <option>5 stele</option>
            <option>4+ stele</option>
            <option>3+ stele</option>
          </select>
        </div>

        <div className="filter-item stylish-select">
          <label htmlFor="price-select"> Preț:</label>
          <select id="price-select">
            <option>Toate</option>
            <option>Sub 500€</option>
            <option>500€ - 1000€</option>
            <option>Peste 1000€</option>
          </select>
        </div>

        <div className="filter-item stylish-select">
          <label htmlFor="activity-select"> Activitate:</label>
          <select id="activity-select">
            <option>Toate</option>
            <option>Mare</option>
            <option>Munte</option>
            <option>City Break</option>
          </select>
        </div>
        
        <button className="filter-button">
          Filtrează
        </button>
      </div>
    </section>
  );
}