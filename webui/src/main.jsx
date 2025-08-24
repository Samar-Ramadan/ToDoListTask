import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css'
import App from './App.jsx'
import Login from './Login.jsx'
import ToDoApp from './ToDoApp.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
        <App />
        {/*<Login />*/}
        {/*<ToDoApp />*/}
  </StrictMode>,
)
