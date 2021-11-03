import { Menu } from 'antd';
import './Nav.scss'
import {
    HomeOutlined,
    DesktopOutlined,
    ExclamationCircleOutlined,
    UserOutlined,
} from '@ant-design/icons';
import { Link } from 'react-router-dom';
const Nav = () => {
    return (
        <Menu
            className="menu"
            defaultSelectedKeys={['1']}
            defaultOpenKeys={['sub1']}
            mode="inline"
            theme="dark"
        >
            <Menu.Item key="1" icon={<HomeOutlined />}>

                <Link to="/">Home</Link>
            </Menu.Item>
            <Menu.Item key="2" icon={<DesktopOutlined />}>

                <Link to="/camera">Camera</Link>
            </Menu.Item>
            <Menu.Item key="3" icon={<ExclamationCircleOutlined />}>

                <Link to="/violator">Violator</Link>
            </Menu.Item>
            <Menu.Item key="4" icon={<UserOutlined />}>

                <Link to="/people">People</Link>
            </Menu.Item>
        </Menu>
    )
}

export default Nav;