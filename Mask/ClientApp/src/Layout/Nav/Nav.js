import { Menu } from 'antd';
import './Nav.scss'
import {
    HomeOutlined,
    DesktopOutlined,
    ExclamationCircleOutlined,
    UserOutlined,
} from '@ant-design/icons';
import { Link } from 'react-router-dom';
import { useLocation } from 'react-router';
const Nav = () => {
    const location = useLocation().pathname.split('/')[1];
    return (
        <Menu
            className="menu"
            mode="inline"
            theme="dark"
        >
            <Menu.Item key="1" icon={<HomeOutlined />}  style={{ backgroundColor: location === '' ? 'gray' : '' }}>

                <Link to="/">Home</Link>
            </Menu.Item>
            <Menu.Item key="2" icon={<DesktopOutlined />}  style={{ backgroundColor: location === 'camera' ? 'gray' : '' }}>

                <Link to="/camera">Camera</Link>
            </Menu.Item>
            <Menu.Item key="3" icon={<ExclamationCircleOutlined />}  style={{ backgroundColor: location === 'violator' ? 'gray' : '' }}>

                <Link to="/violator">Violator</Link>
            </Menu.Item>
            <Menu.Item key="4" icon={<UserOutlined />}  style={{ backgroundColor: location === 'people' ? 'gray' : '' }}>

                <Link to="/people">People</Link>
            </Menu.Item>
        </Menu>
    )
}

export default Nav;