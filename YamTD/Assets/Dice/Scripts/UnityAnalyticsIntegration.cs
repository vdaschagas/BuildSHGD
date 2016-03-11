using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
//	int totalPotions = 5;
//	int totalCoins = 100;
//	string weaponID = "Weapon_102";

	// Use this for initialization
	void Start () {
		
		const string projectId = "fa7894a4-1c7f-47cf-99e1-8251bab862da";

		UnityAnalytics.StartSDK (projectId);



		Gender gender = Gender.Female;
		UnityAnalytics.SetUserGender(gender);
		
		int birthYear = 2014;
		UnityAnalytics.SetUserBirthYear(birthYear);


/*  productId string The id of the purchased item. 
	price decimal The price of the item. 
	currency string Abbreviation of the currency used for the transaction. For example “USD” (United States Dollars). See here for a standardized list of currency abbreviations. 
	receipt string Receipt data (iOS) or receipt ID (Android) for in-app purchases to verify purchases with Apple iTunes or Google play. Use null in the absence of receipts. For more details see Receipt Verification. 
	signature string Android receipt signature. If using native Android use the INAPP_DATA_SIGNATURE string containing the signature of the purchase data that was signed with the private key of the developer. The data signature uses the RSASSA-PKCS1-v1_5 scheme. Pass in null in the absence of a signature. 

	UnityAnalytics.Transaction("12345abcde", 0.99m, "USD", null, "INAPP_DATA_SIGNATURE");
*/
	}

}
