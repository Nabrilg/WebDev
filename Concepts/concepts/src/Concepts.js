import React, { useEffect, useState } from 'react';
import './App.css';
import { Link } from 'react-router-dom';
import Cookie from 'universal-cookie';

const baseURL = `https://javerianawebdevapi.azurewebsites.net/api/Concepts`;


function Concepts(){

    useEffect(() => {
        fetchConcepts();
    }, []);

    const [concepts, setConcepts] = useState([]);
    
    const fetchConcepts = async () =>{
        var cookie = new Cookie();
        const data = await fetch(baseURL,{
            method: 'get',
            headers: new Headers({
                'Authorization' : cookie.get('Authorization')
            })
        });

        const concepts = await data.json();
        setConcepts(concepts);
    };

    const deleteConcept = async (conceptId) =>{
        var cookie = new Cookie();
        const deleteConceptUrl = baseURL + '/' + conceptId;
        console.log(deleteConceptUrl);
        const data = await fetch(deleteConceptUrl,{
            method: 'delete',
            headers: new Headers({
                'Authorization' : cookie.get('Authorization')
            })
        });
        window.location.reload(false);
    }

    return (
        <div className="gradient-bg">
            <div className="concepts-container">
                <h1>Conceptos</h1>
                <p>
                    <Link to={`/createConcept`}>Crear concepto</Link>
                </p>
                <p></p>
                <table className="concepts">
                    <thead>
                        <tr>
                            <th><p>ID</p></th>
                            <th><p>DOMAIN_ID</p></th>
                            <th><p>TRACK</p></th>
                            <th><p>LONG_DESC</p></th>
                            <th><p>SHORT_DESC</p></th>
                            <th><p>CODE_BILLING_STATUS</p></th>
                            <th><p>ANAT_OR_COND</p></th>
                            <th><p>VALID_START_DATE</p></th>
                            <th><p>VALID_END_DATE</p></th>
                            <th><p>ACCIONES</p></th>
                        </tr>
                    </thead>
                    <tbody>
                        {concepts.map( concept => (
                            <tr key = {concept.id}>
                                <td>
                                    <p>{concept.id}</p>
                                </td>
                                <td>
                                    <p>{concept.domain_Id}</p>
                                </td>
                                <td>
                                    <p>{concept.track}</p>
                                </td>
                                <td>
                                    <p>{concept.long_Desc}</p>
                                </td>
                                <td>
                                    <p>{concept.short_Desc}</p>
                                </td>
                                <td>
                                    <p>{concept.code_Billing_Status}</p>
                                </td>
                                <td>
                                    <p>{concept.anat_Or_Cond}</p>
                                </td>
                                <td>
                                    <p>{concept.valid_Start_Date}</p>
                                </td>
                                <td>
                                    <p>{concept.valid_End_Date}</p>
                                </td>
                                <td>
                                    <p>
                                        <Link to={{pathname:`/concept/${concept.id}`, concepto : concept}}>Editar</Link>
                                    </p>
                                    <a href="javascript:void(0)" onClick={ () => { deleteConcept(concept.id) }}>Eliminar</a>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                
            </div>
        </div>
    );
}

export default Concepts;

