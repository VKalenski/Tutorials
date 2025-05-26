# **Vagrant**

- https://developer.hashicorp.com/vagrant
- https://developer.hashicorp.com/vagrant/tutorials/getting-started/getting-started-index

---

### **Initialize a project directory**

|Commands|Description|
|:-|:-|
|vagrant                                    |Check the installation|
|mkdir vagrant_getting_started              |Make a new directory for the project|
|cd vagrant_getting_started                 |Move into directory|
|vagrant init hashicorp/bionic64            |Initialize the directory and specify the hashicorp/bionic64 box|

---

### **Install and specify a box**

|Commands                                   |Description|
|:-                                         |:-|
|vagrant box add hashicorp/bionic64         |Add a box to Vagrant|
|vagrant up                                 |Bring up a virtual machine|
|vagrant ssh                                |SSH into the machine|
|logout                                     |Terminate the SSH session|
|vagrant destroy                            |Destroy the machine|
|vagrant box list                           |List your box files|
|vagrant box remove hashicorp/bionic64      |Remove the box|

#### [🔼 Back to top](#vagrant)

---

### **Synchronize local and guest files**

|Commands                                   |Description|
|:-                                         |:-|
|vagrant up                                 |Create and configure a guest machine|
|vagrant ssh                                |SSH into virtual machine to see the synched file|
|ls /vagrant                                |Explore the synced folder|
|touch /vagrant/foo                         |Test the synced folder|
|exit                                       |End your SSH session|
|ls                                         |List the contents local vagrant directory|

#### [🔼 Back to top](#vagrant)

---

### **Share an environment**

|Commands                                   |Description|
|:-                                         |:-|
|vagrant plugin install vagrant-share       |Install vagrant share plugin|
|vagrant share                              |Share the environment|
|^C                                         |End the sharing session|

#### [🔼 Back to top](#vagrant)

---

### **Teardown an environment**
|Commands                                   |Description|
|:-                                         |:-|
|vagrant suspend                            |Suspend the machine|
|vagrant up                                 |Start the machine|
|vagrant halt                               |Halt the machine|
|vagrant destroy                            |Destroy the machine|

#### [🔼 Back to top](#vagrant)