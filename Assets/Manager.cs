using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private static Manager _instance;
    [SerializeField]
    private GameObject TR, Credit, Heat, Energy, Plants, Titanium, Steel, setterWindow, setterWindowInnerPanel, productionSettings;
    private int[] resourceQuantities;
    private int[] resourceProductions;
    [SerializeField]
    private int activeType;

    public static Manager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resourceQuantities = new int[7];
        resourceProductions = new int[7];
        activeType = 1;
        for ( int i = 0; i < 6; i++)
        {
            resourceQuantities[i] = 0;
            resourceProductions[i] = 0;
        }

        Button btnTR = TR.GetComponent<Button>(); //Grabs the button component
        Button btnCredit = Credit.GetComponent<Button>(); //Grabs the button component
        Button btnHeat = Heat.GetComponent<Button>(); //Grabs the button component
        Button btnEnergy = Energy.GetComponent<Button>(); //Grabs the button component
        Button btnPlants = Plants.GetComponent<Button>(); //Grabs the button component
        Button btnTitanium = Titanium.GetComponent<Button>(); //Grabs the button component
        Button btnSteel = Steel.GetComponent<Button>(); //Grabs the button component


        updateValues();


        btnTR.onClick.AddListener(delegate { TaskOnClick(0); }); //Adds a listner on the button
        btnCredit.onClick.AddListener(delegate { TaskOnClick(1); }); //Adds a listner on the button
        btnHeat.onClick.AddListener(delegate { TaskOnClick(2); }); //Adds a listner on the button
        btnEnergy.onClick.AddListener(delegate { TaskOnClick(3); }); //Adds a listner on the button
        btnPlants.onClick.AddListener(delegate { TaskOnClick(4); }); //Adds a listner on the button
        btnTitanium.onClick.AddListener(delegate { TaskOnClick(5); }); //Adds a listner on the button
        btnSteel.onClick.AddListener(delegate { TaskOnClick(6); }); //Adds a listner on the button
    }

    public void updateSetterWindowValues()
    {
        setterWindowInnerPanel.transform.Find("QuantityValue").GetComponent<Text>().text = resourceQuantities[activeType].ToString();
        productionSettings.transform.Find("ProductionValue").GetComponent<Text>().text = resourceProductions[activeType].ToString();
    }

    public void updateValues()
    {
        TR.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[0].ToString();
        Credit.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[1].ToString();
        Heat.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[2].ToString();
        Energy.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[3].ToString();
        Plants.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[4].ToString();
        Titanium.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[5].ToString();
        Steel.transform.Find("Quantity").GetComponent<Text>().text = resourceQuantities[6].ToString();

        Credit.transform.Find("production_amount").GetComponent<Text>().text = resourceProductions[1].ToString();
        Heat.transform.Find("production_amount").GetComponent<Text>().text = resourceProductions[2].ToString();
        Energy.transform.Find("production_amount").GetComponent<Text>().text = resourceProductions[3].ToString();
        Plants.transform.Find("production_amount").GetComponent<Text>().text = resourceProductions[4].ToString();
        Titanium.transform.Find("production_amount").GetComponent<Text>().text = resourceProductions[5].ToString();
        Steel.transform.Find("production_amount").GetComponent<Text>().text = resourceProductions[6].ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exit ()
    {
        Application.Quit();
    }

    public void increaseProduction()
    {
        resourceProductions[activeType] += 1;
        updateSetterWindowValues();
    }

    public void decreaseProduction()
    {
        resourceProductions[activeType] -= 1;
        updateSetterWindowValues();
    }

    public void increaseResource ()
    {
        resourceQuantities[activeType] += 1;
        updateSetterWindowValues();
    }

    public void decreaseResource()
    {
        resourceQuantities[activeType] -= 1;
        updateSetterWindowValues();
    }

    void TaskOnClick(int type)
    {
        activeType = type;
        setterWindowInnerPanel.transform.Find("QuantityValue").GetComponent<Text>().text = resourceQuantities[activeType].ToString();
        productionSettings.transform.Find("ProductionValue").GetComponent<Text>().text = resourceProductions[activeType].ToString();
        if (activeType == 0)
        {

            productionSettings.SetActive(false);
        } else
        {

            productionSettings.SetActive(true);
        }
        setterWindow.SetActive(true);
    }
    public void close(int type)
    {
        updateValues();
        setterWindow.SetActive(false);
    }
}
