'use strict';

// HTML as the serialized form of the DOM

function start() {
  document.body.children[0];
  // ^ that will fail if the DOM isn't loaded yet by the browser

  document.body.children[0].href;

  // html attributes often correspond to DOM properties
  // which we can access and modify

  document.body.children[0].href = 'http://google.com';
}

// window.onload = start;
// 100 lines of code
// window.onload = start2;

// more flexible, supports multiple event handler functions
// window.addEventListener('load', start);

// the "load" event waits for EVERYTHING in that element
// including slow things like downloading images

// we can run as soon as the dom objects exist
document.addEventListener('DOMContentLoaded', () => {
  //   document.getElementsByTagName('ul')[0];
  //   document.body.children[2];
  const list = document.getElementById('list');

  const button = document.createElement('button');
  button.textContent = 'click here';

  button.addEventListener('click', () => {
    const item = document.createElement('li');
    list.appendChild(item);
    // item.textContent = 'text';
    item.innerHTML = '<em>text</em>';
    // item.addEventListener('click', printEventDetails);
  });

  document.body.appendChild(button);

  document.addEventListener('click', printEventDetails);
  // button.addEventListener('click', printEventDetails);
  // list.addEventListener('click', printEventDetails);
});

// let mostRecentEvent = null; // is it the same object that bubbles? no

function printEventDetails(event) {
  // console.log(event === mostRecentEvent); // always false
  // console.log(`type: ${event.type}`);
  console.log(`target:`); // the most specific element the event ran on
  console.log(event.target);
  console.log(`currentTarget:`); // the element this event handler was
                                 // registered on
  console.log(event.currentTarget);
  console.log('-------------------');
  // mostRecentEvent = event;
}

// if the user clicks on a list item, it should delete that list item.
