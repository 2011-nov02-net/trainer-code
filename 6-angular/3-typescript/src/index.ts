interface Message {
  text: string;
}

document.addEventListener('DOMContentLoaded', () => {
  addMessage({ text: 'hello world' });
});

function addMessage(message: Message) {
  document.body.innerHTML = message.text;
}
