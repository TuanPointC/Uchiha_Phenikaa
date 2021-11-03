import { Button } from 'antd';
import './HeaderLayout.scss'
const HeaderLayout = () => {
    return (
        <div className="headerLayout">
            <div className="logo">Uchiha Phenikaa</div>
            <div className="userName">User name</div>
            <div className="function">
                <Button type="primary" className="login-button">Login</Button>
                <Button type="primary">Register</Button>
            </div>
        </div>
    )
}

export default HeaderLayout;