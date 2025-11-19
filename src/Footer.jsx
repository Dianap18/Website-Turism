export default function Footer() {
  return (
    <div className="footer-wrapper"> 
      <footer className="footer">
        
    
        <div className="footer-col">
            <a href="/" className="nav-logo">
                <h2 style={{ color: '#0077ff', marginBottom: '15px' }}>
                    <sup>Travel</sup>GUIDE
                </h2>
            </a>
            <p style={{ marginTop: '0' }}>Ghidul tău spre cele mai spectaculoase destinații. Planifică-ți aventura perfectă!</p>
            <div className="footer-icons">
                <a href="https://www.instagram.com/" aria-label="Instagram"><i className="fa-brands fa-instagram"></i></a>
                <a href="https://www.facebook.com/" aria-label="Facebook"><i className="fa-brands fa-facebook"></i></a>
                <a href="https://twitter.com/" aria-label="Twitter"><i className="fa-brands fa-twitter"></i></a>
            </div>
        </div>

        <div className="footer-col">
          <h2>Linkuri Ajutătoare</h2>
          <a href="/">Acasă</a>
          <a href="/destinatii">Destinații</a>
          <a href="/preturi">Prețuri</a>
          <a href="/contact">Contact</a>
        </div>
        
        <div className="footer-col footer-newsletter">
          <h2>Noutăți</h2>
          <form>
            <input type="email" placeholder="Adresa dvs. de email" required />
            <br />
            <button type="submit">ABONEAZĂ-TE</button>
          </form>
        </div>

        <div className="footer-col">
          <h2>Contact</h2>
          <p>123, Strada X, nr. Z<br />Mureș, Romania</p>
          <p>Email: contact@travelguide.ro</p>
          <p>Telefon: +40 7xy zzz xxx</p>
        </div>


        <div className="footer-copyright">
          &copy; {new Date().getFullYear()} <i><sup>Travel</sup>GUIDE</i> realizat de Purenciu Diana
        </div>
      </footer>
    </div>
  );
}