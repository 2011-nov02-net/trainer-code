'use strict';

document.addEventListener('DOMContentLoaded', () => {
  const resultsElement = document.createElement('div');
  const errorElement = document.createElement('div');
  errorElement.style.color = 'red';

  function contactApi() {
    if (resultsElement.parentNode) {
      document.body.removeChild(resultsElement);
    }
    if (errorElement.parentNode) {
      document.body.removeChild(errorElement);
    }

    // browser gives us this object to send HTTP with
    const xhr = new XMLHttpRequest();

    // as a request-response cycle occurs,
    // xhr's "readyState" property advances from 0 to 4.
    // https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest/readyState

    // there's a "readystatechange" event that we can use to
    // react to that process.

    xhr.addEventListener('readystatechange', () => {
      if (xhr.readyState === 4) {
        // we have the whole response
        if (xhr.status >= 200 && xhr.status <= 299) {
          // display results
          const result = xhr.response.result; // relies on responsetype=json
          resultsElement.textContent = result;
          document.body.appendChild(resultsElement);
        } else {
          // display error
          // browser has a built-in JSON.parse and JSON.stringify
          // functions for JSON serialization.
          let error = JSON.parse(xhr.responseText).error;
          if (!error) {
            error = 'unknown';
          }
          errorElement.textContent = `${xhr.status} error, ${error}`;
          document.body.appendChild(errorElement);
        }
      }
    });

    const url = 'https://newton.now.sh/api/v2/simplify/2^2%2b2(2)';

    // setting up the request, not sent yet
    xhr.open('get', url);
    xhr.setRequestHeader('Accept', 'application/json');
    // request is sent
    xhr.responseType = 'json'; // now xhr.response will be object, not string
    xhr.send();

    console.log('request sent');
  }

  const form = document.getElementById('calculate-form');
  form.addEventListener('submit', event => {
    event.preventDefault();

    contactApi();
  });
});
