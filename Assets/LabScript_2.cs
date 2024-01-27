using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabScript_2 : MonoBehaviour
{
    // Intermediate Game Development Lab 3 Sub-Assignment 2
    // Written by Jacob Dreyer

    //Cover price of book is $X
    //Bookstore gets a 40% discount
    //Shipping costs $3 for first copy, and .75 for each additional copy

    //Wholesale cost = Price to purchase all the books before it goes to the customer
    //In this case, it is just (CoverPrice * Copies) * (1-DISCOUNT)
    //Profit before shipping = 40% of the CoverPrice * Copies (since that is money saved)

    const float STORE_PERCENT_DISCOUNT = .4f;
    const float INITAL_COPY_SHIPPING = 3f;
    const float COPY_COST_SHIPPING = .75f;
    [Header("Set the cover price in USD")]
    public float coverPrice = 0.00f;
    [Header("Set the amount of copies the store has sold")]
    public int copiesToSell = 0;

    private float shippingCosts = 0.00f;
    float wholesaleCost;

    // Start is called before the first frame update
    void Start()
    {
        CalculateWholesaleCost();
        CalculateShippingCost();
        Debug.LogFormat("Wholesale Cost (before shipping): ${0} \n Profit (before shipping): ${1} Cost of shipping: ${2}", wholesaleCost, (coverPrice * copiesToSell)-wholesaleCost, shippingCosts);
    }
    void CalculateWholesaleCost()
    {
        //Wholesale is how much it costs to buy all of the books
        wholesaleCost = coverPrice * copiesToSell * (1-STORE_PERCENT_DISCOUNT);
        
    }
    void CalculateShippingCost()
    {
        //Compare to the copies ordered
        for(int i = 0; i< copiesToSell; i++)
        {
            if(i == 0) //Only for counting the first copy, the inital shipping price is 3 dollars
            {
                shippingCosts += INITAL_COPY_SHIPPING;
            }
            else
            {
                shippingCosts += COPY_COST_SHIPPING;
            }
        }
    }



}
