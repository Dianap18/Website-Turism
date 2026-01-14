import './Banner.css';

export default function Banner() {
  return (
    <section className="banner">
      <div className="banner-overlay"></div>

      <div className="banner-content">
        <h1 className="banner-title">Descoperă lumea în ritmul tău</h1>
        <p className="banner-subtitle">
          Ghiduri de călătorie, inspirație și rezervări pentru destinațiile tale preferate.
        </p>
      </div>
    </section>
  );
}
