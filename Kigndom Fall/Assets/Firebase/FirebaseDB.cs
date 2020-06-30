using Firebase;
using Firebase.Database;
using UnityEngine;
using Firebase.Unity.Editor;

public class FirebaseDB : MonoBehaviour
{
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://kingdom-fall-2020.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

}