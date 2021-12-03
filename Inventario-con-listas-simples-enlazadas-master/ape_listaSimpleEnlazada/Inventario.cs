using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_listaSimpleEnlazada
{
    class Inventario
    {
        Producto ultimo, primero, anterior, encontrado, temp;

        public Inventario()
        {
            primero = null;
        }

        public void agregar(Producto nuevoP)
        {
            if (primero == null)
            {
                primero = nuevoP;
                ultimo = nuevoP;
            }
            else
            {
                ultimo.siguiente = nuevoP;
                ultimo = nuevoP;
            }
        }

        public void agregarEnInicio(Producto prodEnInicio)
        {
            if (primero == null)
            {
                primero = prodEnInicio;
                ultimo = prodEnInicio;
            }
            else
            {
                prodEnInicio.siguiente = primero;
                primero = prodEnInicio;
            }
        }

        public void insertar(Producto prodAInsertar, int posicion)
        {
            if (posicion == 1)
                agregarEnInicio(prodAInsertar);
            else
            {
                int vcont = 2;
                temp = primero;

                while (vcont < posicion)
                {
                    temp = temp.siguiente;
                    vcont++;
                }

                prodAInsertar.siguiente = temp.siguiente;
                temp.siguiente = prodAInsertar;
            }
        }

        public Producto buscar(int codigoP)
        {
            temp = primero;
            encontrado = null;

            while (encontrado == null && temp != null)
                if (temp.codigo == codigoP)
                    encontrado = temp;
                else
                {
                    anterior = temp;
                    temp = temp.siguiente;
                }

            return encontrado;
        }

        public bool eliminar(int codigoP)
        {
            if (buscar(codigoP) != null)
            {
                if (encontrado == primero)
                    primero = primero.siguiente;
                else
                    anterior.siguiente = encontrado.siguiente;

                return true;
            }
            else
                return false;
        }

        public string mostrar()
        {
            string vProducto = "";
            temp = primero;

            while (temp != null)
            {
                vProducto += temp.ToString() + Environment.NewLine;
                temp = temp.siguiente;
            }

            return vProducto;
        }
    }
}
