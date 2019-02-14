package RestMongo;

import java.util.List;
import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

@RepositoryRestResource(collectionResourceRel = "pizzas", path = "pizzas")
public interface PizzaRepository extends MongoRepository<Pizza, String> {

    @Override
    List<Pizza> findAll();
}
