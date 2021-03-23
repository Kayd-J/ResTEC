package com.example.app

import android.content.Context
import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.recyclerview.widget.RecyclerView
import com.squareup.picasso.Picasso
import kotlinx.android.synthetic.main.platillo.view.*

class PlatillosAdapter(val platillo:List<Platillo>, private val contexto: Context):RecyclerView.Adapter<PlatillosAdapter.AdaptadorPlatillos>(){

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AdaptadorPlatillos {
        val layoutInflater = LayoutInflater.from(parent.context)
        return AdaptadorPlatillos(layoutInflater.inflate(R.layout.platillo, parent, false), contexto)
    }

    override fun getItemCount(): Int {
        return platillo.size
    }

    override fun onBindViewHolder(holder: AdaptadorPlatillos, position: Int) {
        holder.renderizar(platillo[position])
    }

    class AdaptadorPlatillos(val view:View, var contexto: Context): RecyclerView.ViewHolder(view){

        //Se crea el array para almacenar los menus seleccionados
        var platillos_seleccionados = ArrayList<String>()
        var precio_platillos_seleccionados = ArrayList<Int>()

        fun renderizar(platillo: Platillo){

            view.lblnombreplatillo.text = platillo.nombre_platillo
            view.lbldescripcion.text = platillo.descripcion_platillo
            view.lblcosto.text = platillo.precio_platillo.toString()
            Picasso.get().load(platillo.imagen_platillo).into(view.imgview)

            //Selección del intem del menú
            view.setOnClickListener {
                
                //Toast.makeText(view.context, platillo.nombre_platillo, Toast.LENGTH_SHORT).show()
                if(platillo.descripcion_platillo == "ACEPTAR"){
                    Toast.makeText(view.context, "ACEPTAR", Toast.LENGTH_SHORT).show()
                    contexto.startActivity(Intent(contexto, AdministrarCarrito::class.java).
                    putStringArrayListExtra("platillos", platillos_seleccionados))
                }
                //AQUÍ ES DONDE YO QUIERO AGREGAR CADA ITEM SELCCIONADO A UN ARRAY PERO NO SE PUEDE
                //Agregar_item_elemento(platillo.nombre_platillo, platillos_seleccionados)
                Toast.makeText(view.context, platillo.nombre_platillo, Toast.LENGTH_SHORT).show()
            }
        }


        private fun Agregar_item_elemento(elemento: String, elementos: ArrayList<String>): ArrayList<String>{

            //Si el tamaño del array es igual a cero se almacena el elemento en dicha
            if (elementos.size == 0){
                elementos.add(elemento)
                return elementos
            }
            //Si la posición es diferente de cero se toma la medida del largo del array y se le resta una
            //posición para colocar el nuevo elemento en la última posición del array y así no tener
            //conflictos
            else{
                val posicion = elementos.size -1
                elementos.add(posicion, elemento)
                return elementos
            }
        }
    }
}