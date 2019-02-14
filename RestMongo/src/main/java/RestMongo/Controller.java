package RestMongo;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(value = "/pizzas")
public class Controller {

    @Autowired
    private PizzaRepository repository;

    // Erregistratuta dauden produktu guztiak kontsultatu
    @RequestMapping(value = "/getAll", method = RequestMethod.GET)
    public List<Pizza> getAllPizzas() {
        return repository.findAll();
    }
}
