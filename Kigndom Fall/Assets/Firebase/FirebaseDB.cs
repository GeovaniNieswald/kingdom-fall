using Firebase;
using Firebase.Database;
using UnityEngine;
using Firebase.Unity.Editor;

public class FirebaseDB : MonoBehaviour
{
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://kingdom-fall-2020.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        Debug.LogError("teste");
    }

}