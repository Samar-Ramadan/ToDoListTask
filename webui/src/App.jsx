import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Login from "./Login"
import ToDoApp from "./ToDoApp"

function App() {
  const [count, setCount] = useState(0)
    const [isLoggedIn, setIsLoggedIn] = useState(
        !!localStorage.getItem("token")
    );
  return (
      
      <div>
          {isLoggedIn ? (
              <ToDoApp />
          ) : (
              //onLoginSuccess = {() => setIsLoggedIn(true)} 
              <Login />
          )}
      </div>
  )
}

export default App
