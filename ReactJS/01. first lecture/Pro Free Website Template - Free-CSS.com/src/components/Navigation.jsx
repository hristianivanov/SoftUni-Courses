export default function Navigation() {



    return (
        <div id="myNav" className="menu_sid">
            <a href="#" onClick={closeNav} className="closebtn" >&times;</a>
            <div className="menu_sid-content">
                <a href="#protien">Our Protien</a>
                <a href="#about">About Us</a>
                <a href="#testimonial">Testimonial</a>
                <a href="#contact">Contact Us</a>
            </div>
        </div>
    );
}