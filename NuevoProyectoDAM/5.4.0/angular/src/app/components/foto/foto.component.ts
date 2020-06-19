import { Component } from "@angular/core";
import { UserServiceProxy } from "@shared/service-proxies/service-proxies";
import { HttpRequest, HttpClient } from "@angular/common/http";


class ImageSnippet {
    constructor(public src: string, public file: File) {}
  }
  
  @Component({
    selector: 'app-foto',
    templateUrl: 'foto.component.html',
    styleUrls: ['foto.component.css']
  })
  
  export class FotoComponent {
  
  
    constructor(private http: HttpClient) {}

  uploadFile(event) {
    if (event.target.value) {
        const file = event.target.files[0];
        let formData = new FormData();

        formData.append("file", file);
        this.http.post('http://localhost:21021/api/services/app/UsuarioLogado/UploadFoto', formData)
        .subscribe(result => {
          console.log(result);
          this.pageRefresh();
        });
      } else {
       alert('Nothing');
     }
  }
  pageRefresh() {
    location.reload();
  }

}
