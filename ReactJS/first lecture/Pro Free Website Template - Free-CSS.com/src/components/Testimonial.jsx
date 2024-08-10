export default function Testimonial() {
    return (
        <div id="testimonial" className="testimonial">
            <div className="container-fluid">
                <div className="row">
                    <div className="col-md-12">
                        <div className="titlepage">
                            <h2>Testimonial</h2>
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-5">
                        <div className="body_blu_img">
                            <figure><img src="images/tesr.png" alt="#" /></figure>
                        </div>
                    </div>
                    <div className="col-md-7 pad_right0">
                        <div className="testimo_ban_bg">
                            <div id="testimo" className="carousel slide testimo_ban" data-ride="carousel">
                                <ol className="carousel-indicators">
                                    <li data-target="#testimo" data-slide-to="0" className="active"></li>
                                    <li data-target="#testimo" data-slide-to="1"></li>
                                    <li data-target="#testimo" data-slide-to="2"></li>
                                </ol>
                                <div className="carousel-inner">
                                    <div className="carousel-item active">
                                        <div className="container">
                                            <div className="carousel-caption relative2">
                                                <div className="row d_flex">
                                                    <div className="col-md-11">
                                                        <i><img src="images/costu.png" alt="#" /></i>
                                                        <span>Consectetur</span>
                                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="carousel-item">
                                        <div className="container">
                                            <div className="carousel-caption relative2">
                                                <div className="row d_flex">
                                                    <div className="col-md-11">
                                                        <i><img src="images/costu.png" alt="#" /></i>
                                                        <span>Consectetur</span>
                                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div className="carousel-item">
                                        <div className="container">
                                            <div className="carousel-caption relative2">
                                                <div className="row d_flex">
                                                    <div className="col-md-11">
                                                        <i><img src="images/costu.png" alt="#" /></i>
                                                        <span>Consectetur</span>
                                                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <a className="carousel-control-prev" href="#testimo" role="button" data-slide="prev">
                                        <i className="fa fa-angle-left" aria-hidden="true"></i>
                                        <span className="sr-only">Previous</span>
                                    </a>
                                    <a className="carousel-control-next" href="#testimo" role="button" data-slide="next">
                                        <i className="fa fa-angle-right" aria-hidden="true"></i>
                                        <span className="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}