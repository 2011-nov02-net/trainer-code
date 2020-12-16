import { platformBrowser } from '@angular/platform-browser';
import { AppModule } from './app.module';

platformBrowser().bootstrapModule(AppModule)
    .catch(console.error);

// in angular, you need a root module
// as an "entry point" for the app,
// and the root module needs a root component
//   as its entry point, to contain all the
//   components nested within it.
