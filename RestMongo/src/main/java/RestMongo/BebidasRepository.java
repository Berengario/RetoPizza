package RestMongo;

import java.util.List;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

@RepositoryRestResource(collectionResourceRel = "pizzas", path = "pizzas")
public interface BebidasRepository extends MongoRepository<Pizza, String> {

    @Override
    List<Pizza> findAll();

    Pizza findByNombre(@Param("Nombre") String Nombre);
    
    @Override
    void deleteById(String Id);
}
