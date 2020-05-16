import { NuevoProyectoDAMTemplatePage } from './app.po';

describe('NuevoProyectoDAM App', function() {
  let page: NuevoProyectoDAMTemplatePage;

  beforeEach(() => {
    page = new NuevoProyectoDAMTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
