export default function About() {
    return (
        <div id="about" className="about">
            <div className="container-fluid">
                <div className="row d_flex">
                    <div className="col-md-6">
                        <div className="titlepage">
                            <h2>About Us</h2>
                            <p>It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or</p>
                            <a className="read_more" href="#"> Read More</a>
                        </div>
                    </div>
                    <div className="col-md-6 pad_right0">
                        <div className="about_img ">
                            <figure><img src="images/about.png" alt="#" /></figure>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}