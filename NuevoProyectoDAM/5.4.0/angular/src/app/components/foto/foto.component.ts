import { Component } from "@angular/core";
import { UsuarioLogadoServiceProxy } from "@shared/service-proxies/service-proxies";
import { HttpClient } from "@angular/common/http";

class ImageSnippet {
    constructor(public src: string, public file: File) {}
  }
  
  @Component({
    selector: 'app-foto',
    templateUrl: 'foto.component.html',
    styleUrls: ['foto.component.css']
  })
  
  export class FotoComponent {
  
    selectedFile: File = null;
    uploadedFiles: Array < File > ;
  
    constructor(private http: HttpClient){}
  


    fileChange(element) {
      this.uploadedFiles = element.target.files;
    }


    upload() {
      let formData = new FormData();
      for (var i = 0; i < this.uploadedFiles.length; i++) {
          formData.append("uploads[]", this.uploadedFiles[i], this.uploadedFiles[i].name);
      }
      this.http.post('http://localhost:21021/api/FileUpload', formData)
      .subscribe((response) => {
           console.log('response received is ', response);
      })
  }


    processFile(event){
      this.selectedFile = event.target.files[0];

      const fd = new FormData()
      fd.append('image', this.selectedFile)

      this.http.post('https://localhost:21021/api/FileUpload', fd)
      .subscribe(
        res => {
          console.log(res)
        },
        err => {
          console.log(err)
        }
      )
    }

  }

 /* processFile(event){

    const fd = new FormData();
    this.selectedFile = event.target.files[0];
    fd.append('image', this.selectedFile);

    const content_ = JSON.stringify(fd);

    let options_ : any = {
      body: content_,
      observe: "response",
      responseType: "blob",
      headers: new HttpHeaders({
          "Content-Type": "application/json-patch+json",
      })
  };


    this.http.request("post",'http://localhost:21021/api/FileUpload', options_)
    .subscribe(
      res => {
        console.log(res)
      },
      err => {
        console.log(err)
      }
    )
  }*/