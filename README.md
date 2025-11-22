# threads_plus_mutex

Two threads have been created that increment a shared counter up to 10000 in turn. To synchronize access to the shared resource (the counter), a Mutex is used, which prevents data race conditions.


<img width="463" height="563" alt="image" src="https://github.com/user-attachments/assets/2c38148a-fbe4-4d67-b8e1-e745ab9b7ec9" />

Solution Architecture
---------------------
Main components:
Shared resource: a static variable counter
Synchronizer: a static Mutex mutex
Worker threads: two threads executing the COUNTER method
