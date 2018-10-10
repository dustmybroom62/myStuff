from math import sin, cos, atan2, radians, degrees, sqrt, tan

class Force:
    def __init__(self, magnitude, angle):
        self.magnitude = magnitude
        self.angle = angle


    def get_horizontal(self):
        return self.magnitude * cos(radians(self.angle))


    def get_vertical(self):
        return self.magnitude * sin(radians(self.angle))


    def get_angle(self, use_degrees = True):
        if use_degrees:
            return self.angle
        return radians(self.angle)


def find_net_force(forces):
    vTotal = 0
    hTotal = 0
    for f in forces:
        vTotal += f.get_vertical()
        hTotal += f.get_horizontal()

    magnitude = round( (hTotal ** 2 + vTotal ** 2) ** 0.5, 1 )
    angle = round(degrees( atan2(vTotal, hTotal) ), 1 )

    return Force(magnitude, angle)


print('=' * 40)
force_1 = Force(50, 90)
force_2 = Force(75, -90)
force_3 = Force(100, 0)
forces = [force_1, force_2, force_3]
net_force = find_net_force(forces)
print(net_force.magnitude)
print(net_force.get_angle())

class TodoItem:
    def __init__(self, title, description, completed=False):
        self.title = title
        self.description = description
        self.completed = completed
        
    def setTitle(self, val):
        if str == type(val):
            self.title = val
        else:
            self.title = None
            
            
    def setDescription(self, val):
        if str == type(val):
            self.description = val
        else:
            self.description = None
            
            
    def setCompleted(self, val):
        if bool == type(val):
            self.completed = val
        else:
            self.completed = None
            
            
    def getTitle(self):
        return self.title
    
    
    def getDescription(self):
        return self.description
    
    
    def getCompleted(self):
        return self.completed
    

print('=' * 40)
item = TodoItem("Mow", "Mow the lawn")
print(item.getTitle())
print(item.getDescription())
print(item.getCompleted())
item.setCompleted(True)
print(item.getCompleted())
item.setTitle(False)
print(item.getTitle())

class FibSeq:
    def __init__(self):
        self.back1 = 1
        self.back2 = 0


    def next_number(self):
        n = self.back1 + self.back2
        self.back2 = self.back1
        self.back1 = n
        return n


print('=' * 40)
newFib = FibSeq()
print(newFib.next_number())
print(newFib.next_number())
print(newFib.next_number())
print(newFib.next_number())
print(newFib.next_number())


class Meat:
    def __init__(self, value=False):
        self.set_value(value)
            
    def get_value(self):
        return self.value
    
    def set_value(self, value):
        if value in ["chicken", "pork", "steak", "tofu"]:
            self.value = value
        else:
            self.value = False

class Rice:
    def __init__(self, value=False):
        self.set_value(value)
            
    def get_value(self):
        return self.value
    
    def set_value(self, value):
        if value in ["brown", "white"]:
            self.value = value
        else:
            self.value = False
            
class Beans:
    def __init__(self, value=False):
        self.set_value(value)
            
    def get_value(self):
        return self.value
    
    def set_value(self, value):
        if value in ["black", "pinto"]:
            self.value = value
        else:
            self.value = False            

            
class Burrito:
    def __init__(self, meat, to_go, rice, beans,
                 extra_meat=False, guacamole=False,
                 cheese=False, pico=False, corn=False):
        self.set_meat(meat)
        self.set_to_go(to_go)
        self.set_rice(rice)
        self.set_beans(beans)
        self.set_extra_meat(extra_meat)
        self.set_guacamole(guacamole)
        self.set_cheese(cheese)
        self.set_pico(pico)
        self.set_corn(corn)


    def get_cost(self):
        cost = 5.0
        meat = self.meat.get_value()
        if False != meat:
            if meat in ["chicken", "pork", "tofu"]:
                cost += 1.0
            elif meat in ["steak"]:
                cost += 1.5
            if self.extra_meat:
                cost += 1.0
        if self.guacamole:
            cost += 0.75
        return cost


    def get_meat(self):
        return self.meat.get_value()
    

    def set_meat(self, val):
        self.meat = Meat(val)


    def get_to_go(self):
        return self.to_go


    def set_to_go(self, val):
        if val in [True, False]:
            self.to_go = val
        else:
            self.to_go = False


    def get_rice(self):
        return self.rice.get_value()


    def set_rice(self, val):
        self.rice = Rice(val)


    def get_beans(self):
        return self.beans.get_value()
            

    def set_beans(self, val):
        self.beans = Beans(val)


    def get_extra_meat(self):
        return self.extra_meat


    def set_extra_meat(self, val):
        if val in [True, False]:
            self.extra_meat = val
        else:
            self.extra_meat = False


    def get_guacamole(self):
        return self.guacamole


    def set_guacamole(self, val):
        if val in [True, False]:
            self.guacamole = val
        else:
            self.guacamole = False


    def get_cheese(self):
        return self.cheese
        

    def set_cheese(self, val):
        if val in [True, False]:
            self.cheese = val
        else:
            self.cheese = False


    def get_pico(self):
        return self.pico
        

    def set_pico(self, val):
        if val in [True, False]:
            self.pico = val
        else:
            self.pico = False


    def get_corn(self):
        return self.corn
        

    def set_corn(self, val):
        if val in [True, False]:
            self.corn = val
        else:
            self.corn = False
        

print('=' * 40)
newBurrito = Burrito("tofu", True, True, True)
print(newBurrito.to_go)
print(newBurrito.guacamole)

print('=' * 40)
a_burrito = Burrito("pork", False, "white", "black", extra_meat = True) # , guacamole = True)
print(a_burrito.get_cost())

print('=' * 40)
burrito_3 = Burrito("tofu", False, "loeil", "black", extra_meat = False, guacamole = False, cheese = False, pico = False, corn = True)
print(burrito_3.get_cost())

def total_cost(burritos):
    total = 0.0
    for b in burritos:
        total += b.get_cost()
    return total


print('=' * 40)
print(total_cost([newBurrito, a_burrito, burrito_3]))


    
