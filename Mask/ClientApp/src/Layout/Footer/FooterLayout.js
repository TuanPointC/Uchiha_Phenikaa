import { FaLinkedin,FaFacebookF,FaFacebookMessenger,FaTwitter } from "react-icons/fa";
import './FooterLayout.scss'
const FooterLayout = () => {
    return (
        <div className="footerLayout">
            <div className="copyPolicy">
                Copyright © 2017 All Rights Reserved by Uchiha Phenikaa.
            </div>
            <ul className="social-icons">
                <li><FaLinkedin/> </li>
                <li><FaFacebookF/> </li>
                <li><FaFacebookMessenger/> </li>
                <li><FaTwitter/> </li>
            </ul>
        </div>
    )
}

export default FooterLayout;