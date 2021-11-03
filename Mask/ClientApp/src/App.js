import './App.scss'
import { Layout, BackTop } from 'antd';
import Nav from './Layout/Nav/Nav';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Home from './Home/Home';
import Login from './Login/Login';
import Register from './Register/Register';
import People from './People/People';
import Violator from './Violator/Violator';
import HeaderLayout from './Layout/Header/HeaderLayout';
import Camera from './Camera/Camera';
import FooterLayout from './Layout/Footer/FooterLayout';
const { Header, Footer, Sider, Content } = Layout;

function App() {
  return (
    <div className="App">
      <Layout>
        <Router>
          <Header>
            <HeaderLayout />
          </Header>

          <Layout>

            <Sider>
              <Nav />
            </Sider>


            <Content className="content">
              <Switch style={{ padding: 24, minHeight: 380 }}>
                <Route exact path="/">
                  <Home />
                </Route>
                <Route exact path="/people">
                  <People />
                </Route>
                <Route exact path="/camera">
                  <Camera />
                </Route>
                <Route path="/violator" >
                  <Violator />
                </Route>
                <Route path="/login" >
                  <Login />
                </Route>
                <Route path="/register" >
                  <Register />
                </Route>
              </Switch>

              <BackTop>
                <div className="backTop">UP</div>
              </BackTop>
            </Content>
          </Layout>

          <Footer className="footer">
            <FooterLayout />
          </Footer>
        </Router>
      </Layout>

    </div>
  );
}

export default App;
