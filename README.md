# Intrusion Detection System (IDS)

Welcome to the Intrusion Detection System (IDS) repository! This project was aimed at developing an Intrusion Detection System for detecting and alerting potential intrusions or suspicious activities on a network.

![Image](ids.png)

## About the Project

The Intrusion Detection System (IDS) is a project that aimed to evaluate network traffic based on a set of predefined rules. It analyzed each packet circulating on the network and checked for suspicious behavior according to the rules configured previously. When a packet was flagged as potentially malicious, the IDS triggered an alert.

The presente project was developed in C# with a Windows Form interface, which limits its usage to the Windows operation system. This is something I would change has it represents a significant restriction.

Please note that this project is no longer being developed. It only served as a learning experience.

## Features

- Rule-based detection: The IDS evaluated network traffic based on predefined rules to identify potential intrusions.
- Alerting system: When suspicious activity was detected, the IDS triggered an alert to notify the appropriate parties.
- Configurable rules: Easily customize and modify the rules to suit specific security requirements.
- Pcap file analysis: The IDS was not only able to analyse real-time packets in the network but also packets previously captured to a .pcap file.

## Usage

As the project is no longer being actively developed, please note that it may have known bugs or limitations that were not resolved.

Necessary tool to install:
- Npcap

To use the project is necessary the installation of the following librarys:
- SharpPcap
- PacketDotNet
- Newtonsoft.Json

## Contact

If you have any questions related to the IDS project feel free to contact me in my LikedIn: [https://www.linkedin.com/in/teresa-sousa/]

Thank you for your interest in the Intrusion Detection System project!
