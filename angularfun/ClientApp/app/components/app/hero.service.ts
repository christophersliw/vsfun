import { Hero } from './hero';
import { HEROES } from './mock-heroes';
import { Injectable } from '@angular/core';

@Injectable()
export class HeroService {
  getHeroes(): Promise<Hero[]> {
    return Promise.resolve(HEROES);
  }

  getHeroesSlowly(): Promise<Hero[]> {
    return new Promise(r => {
      // Simulate server latency with 2 second delay
      setTimeout(() => r(this.getHeroes()), 2000);
    });
  }

  getHero(id: number): Promise<Hero> {
    return this.getHeroes().then(heroes => heroes[0]);
  }
}

