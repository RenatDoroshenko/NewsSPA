import logo from './logo.svg';
import './App.css';

import {Home} from './Home';
import {News} from './News';
import {Themes} from './Themes';
import {Navigation} from './Navigation';

import {BrowserRouter, Route, Switch} from 'react-router-dom';


function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <h3 className="m-3 d-flex justify-content-center">
          My Text
        </h3>
        <Navigation />
        <Switch>
          <Route path='/' component={Home} exact/>
          <Route path='/news' component={News} />
          <Route path='/themes' component={Themes} />
        </Switch>
      </div>
    </BrowserRouter>
    
  );
}

export default App;
