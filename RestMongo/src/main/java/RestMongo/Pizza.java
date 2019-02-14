/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package RestMongo;

/**
 *
 * @author Mikel Elizondo
 */
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document(collection = "pizzas")
public class Pizza {

    @Id
    private String id;
    private String Nombre;
    private String[] Precio;
    private String[] Ingredientes;
    private String Alergenos;
    private String Img;

    public String getId() {
        return id;
    }

    public void setId(String Id) {
        this.id = Id;
    }

    public String getImg() {
        return Img;
    }

    public void setImg(String img) {
        this.Img = img;
    }

    public String[] getIngredientes() {
        return Ingredientes;
    }

    public void setIngredientes(String[] ingredientes) {
        this.Ingredientes = ingredientes;
    }

    public String getAlergenos() {
        return Alergenos;
    }

    public void setAlergenos(String alergenos) {
        this.Alergenos = alergenos;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String Name) {
        this.Nombre = Name;
    }

    public String[] getPrecio() {
        return Precio;
    }

    public void setPrecio(String[] precio) {
        this.Precio = precio;
    }
}
