import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { SampbindComponent } from './app/sampbind/sampbind.component';
import { GamesComponent } from './app/games/games.component';

bootstrapApplication(GamesComponent, appConfig)
  .catch((err) => console.error(err));
