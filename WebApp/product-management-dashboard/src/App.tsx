import React from 'react';
import './App.css';
import Dashboard from './components/products/dashboard';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        Product Management Dashboard
      </header>
      <main>
        <Dashboard/>
      </main>
    </div>
  );
}

export default App;
