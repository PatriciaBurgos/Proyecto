import { DAMTemplatePage } from './app.po';

describe('DAM App', function() {
  let page: DAMTemplatePage;

  beforeEach(() => {
    page = new DAMTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
