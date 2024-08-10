export default function Header() {
    return (
        <header>
            <div className="header">
                <div className="menu_sitbar">
                    <ul className="menu">
                        <li><button type="button" >
                            <img onClick={openNav} src="images/menu_icon.png" alt="#" />
                        </button>
                        </li>
                    </ul>
                    <ul className="social_icon">
                        <li><a href="#"><i className="fa fa-facebook" aria-hidden="true"></i></a></li>
                        <li><a href="#"><i className="fa fa-twitter" aria-hidden="true"></i></a></li>
                        <li><a href="#"><i className="fa fa-linkedin" aria-hidden="true"></i></a></li>
                    </ul>
                </div>
                <div className="header_full_bg">
                    <div className="header_top">
                        <div className="container">
                            <div className="row">
                                <div className="col-md-12">
                                    <div className="logo">
                                        <a href="index.html"><img src="images/logo.png" alt="#" /></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="banner">
                        <div className="container-fluid">
                            <div className="row">
                                <div className="col-md-5">
                                    <div className="banner_text">
                                        <h1>Pro<br /> Body Builder Protien</h1>
                                        <a className="get_btn" href="#about" role="button" >About Protien</a> <a className="get_btn" href="#contact" role="button">Contact Us</a>
                                    </div>
                                </div>
                                <div className="col-md-7">
                                    <img className="bann_img" src="images/banner_ing.png" alt="#" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </header>
    );
}