import { TestBed } from '@angular/core/testing';

import { CreatepasswordService } from './createpassword.service';

describe('CreatepasswordService', () => {
  let service: CreatepasswordService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreatepasswordService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
