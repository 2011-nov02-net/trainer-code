import { Message } from './message';
import { MessageFormatter } from './message-formatter';

document.addEventListener('DOMContentLoaded', () => {
  const text = 'hello world';
  const formatter = new MessageFormatter();

  addMessage(formatter.formatMessage(text));
});

function addMessage(message: Message) {
  document.body.innerHTML = message.text;
}
