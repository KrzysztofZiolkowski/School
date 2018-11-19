class Node(object):
    def __init__(self, x, y, f, g, parent):
        self.x = x                    #x- współrzędna x na siatce pól
        self.y = y                    #y- współrzędna y na siatce pól
        self.f = f                    #f- generalny koszt dotarcia do celu
        self.g = g                    #g- składowa kosztu f, odległość aktualnego węzła od puntku początkowego, liczona w liczbach całkowitych, 1 kratka - 1 pkt
        self.parent = parent          #parent - wskazanie na rodzica danego węzła

    # wyświetlaj obiekt jako string
    def __str__(self):
        rep = "Wiersz: " + str(self.x) + " , Kolumna: " + str(self.y) + ", Wartość_f: " + str(self.f)
        return rep

    # definiuj kiedy obiekty są identyczne
    def __eq__(self, other):
        return self.x == other.x and self.y == other.y

    #  stwórz pola
    #  reguły tworzenia:
    # 1) adres wykraczający poza tablicę ( czyli poniżej 0 lub > rozmiaru tablicy )
    # 2) wartość na siatce == 5
    def add_neighbors(self):
        neighbor_list.clear()

        if current_node.x +1 > grid.__len__()-1 or grid[current_node.x+1][current_node.y]==5:
            pass
        else:
            neighbor_list.append(Node(current_node.x + 1, current_node.y, 0, 0, current_node))

        if current_node.x -1 < 0 or grid[current_node.x-1][current_node.y]==5:
            pass
        else:
            neighbor_list.append(Node(current_node.x - 1, current_node.y, 0, 0, current_node))

        if current_node.y-1  < 0 or grid[current_node.x ][current_node.y-1] == 5:
            pass
        else:
            neighbor_list.append(Node(current_node.x, current_node.y-1, 0, 0, current_node))

        if current_node.y+1  > grid.__len__()-1 or grid[current_node.x ][current_node.y+1] == 5:
            pass
        else:
            neighbor_list.append(Node(current_node.x, current_node.y+1, 0, 0, current_node))


if __name__ == '__main__':

    import math
    import numpy

    #importuj z pliku lokalnego grid
    grid = numpy.genfromtxt("grid.txt", delimiter=" ")

    open_list=[]        #węzly do ekspansji
    closed_list=[]      #węzły tworzące drogę do celu
    neighbor_list=[]    #węzły sąsiadów

    current_node = Node(0,0,0,0,None)    #inicjalizacja pola startowego, konkretyzacja węzła current
    open_list.append(current_node)

    while not current_node.x == grid.__len__()-1 or not current_node.y == grid.__len__()-1:     #wykonuj dopóki współrzędne węzła current > współrzędnych celu (> rozmiar siatki)

        if open_list.__len__() == 0:
            print("Droga do celu jest zablokowana, wyznaczenie optymalnej trasy niemożliwe")
            quit()

        else:
            najmniejszy_f= min(open_list, key=lambda x: x.f)
            current_node= najmniejszy_f
            current_node.g = closed_list.__len__()
            closed_list.append(current_node)
            del open_list[open_list.index(current_node)]
            current_node.add_neighbors()

            for elements in neighbor_list:
                if elements in closed_list:   #jeśli sąsiad jest w liście zamkniętej, przejdź do kolejnego sąsiada
                    continue
                elif elements.g > current_node.g + 1 or elements not in open_list:  #sprawdź czy current nie jest na liście otwartej lub nowy koszt g jest mniejszy
                    elements.f = current_node.g+1 + math.sqrt((elements.x - grid.__len__()) ** 2 + (elements.y - grid.__len__()) ** 2) #jeśli warunek prawdziwy, to aktualizuj f
                    open_list.append(elements)

    end_node = grid[current_node.x][current_node.y] = 3
    final_path = current_node.parent
    grid[final_path.x][final_path.y] = 3
    licznik=1   # wyznacza długość drogi końcowej

    while not final_path.x == 0 or not final_path.y == 0: #przechodź do kolejnych rodziców od węzła końcowego do startowego
        final_path = final_path.parent
        grid[final_path.x][final_path.y] = 3
        licznik= licznik+1

    grid[0][0] = 3
    print(grid)
    print("Długość ścieżki: ",licznik)