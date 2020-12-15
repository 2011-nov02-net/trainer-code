import { Message } from './message';

export class MessageFormatter {
  formatMessage(text: string): Message {
    return {
      text: `~~~ ${text.toUpperCase()} ~~~`
    }
  }
}
