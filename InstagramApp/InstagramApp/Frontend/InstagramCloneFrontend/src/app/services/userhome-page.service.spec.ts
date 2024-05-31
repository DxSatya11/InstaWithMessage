import { TestBed } from '@angular/core/testing';

import { UserhomePageService } from './userhome-page.service';

describe('UserhomePageService', () => {
  let service: UserhomePageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserhomePageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
