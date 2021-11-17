import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
import { Navbar, NavItem, Nav, NavbarToggler, Collapse } from 'reactstrap';

import "./Layout.module.css";


function Layout(props) {
  const [isOpen, setIsOpen] = useState(false);
  const toggler = () => setIsOpen(!isOpen);
  
  return (
    <>
      <header>
        <Navbar color="dark" expand='sm' dark>
          <NavLink exact to='/' className='navbar-brand nav-link'>ZHOPA</NavLink>
          <NavbarToggler onClick={toggler} />
          <Collapse navbar isOpen={isOpen} className='justify-content-between'>
            <Nav navbar>
              <NavItem>
                <NavLink to='/about' className='nav-link'>About</NavLink>
              </NavItem>
              <NavItem>
                <NavLink to='/lobby' className='nav-link'>Lobby</NavLink>
              </NavItem>
              <NavItem>
                <NavLink to='/chat' className='nav-link'>Chat</NavLink>
              </NavItem>
              <NavItem>
                <NavLink to='/video' className='nav-link'>Video</NavLink>
              </NavItem>
              <NavItem>
                <NavLink to='/main' className='nav-link'>Main</NavLink>
              </NavItem>
            </Nav>
            <Nav navbar>
              <NavItem>
                <NavLink to='/signin' className='nav-link'>Sign In</NavLink>
              </NavItem>
            </Nav>
          </Collapse>
        </Navbar>
      </header>
      <main>{props.children}</main>
      <footer className='bg-dark text-white text-center'>
        Copyright &copy; 2021 by Maxim, Alexander, Alexander, Ivan, Denis. All rights reserved.
      </footer>
    </>
  );
}

export default Layout;
